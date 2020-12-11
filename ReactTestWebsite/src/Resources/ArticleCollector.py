import urllib.request
import os
import glob
import requests
from bs4 import BeautifulSoup
from selenium import webdriver
from webdriver_manager.chrome import ChromeDriverManager
import time
import json
from json import JSONEncoder

# Globals  
result_folder_name = "Articles"
result_folder_path = result_folder_name + "/"

article_base_url = "https://edition.cnn.com"
main_page_url = article_base_url+"/business/investing"

# Scraping globals
article_container_text ="More from investing"
article_header_container_tag_type = 'section'
article_header_tag_type = 'article'
article_header_link_attribute = 'href'

article_title_tag_type = 'h1'
article_title_filter = {"class": "pg-headline"}
article_content_tag_type = 'div'
article_content_filter = {"class": "zn-body__paragraph"}

# General helper functions
def validate_escape_characters(text, escape_characters):
    valid_text = text
    for escape_character in escape_characters:        
        invalid_escape_character ="\\"+ escape_character
        valid_text = valid_text.replace(invalid_escape_character,escape_character)
    return valid_text
   
def write_text_file(path,content):
    text_file = open(path, "w")
    text_file.write(content)
    text_file.close()
    
def format_json(json_text):
    with_valid_escape_characters = validate_escape_characters(json_text,["\"","\\"])
    return with_valid_escape_characters
    
def prepare_result_folder(path):
    if not os.path.exists(path):
        os.makedirs(path)
    else:
        files = glob.glob(path+'*')
        for f in files:
            os.remove(f)

# Scraping classes
class Article:
    def __init__(self,url,title,article):
        self.url = url
        self.title = title
        self.article = article
    def to_json(self):
        return json.dumps(self, default=lambda o: o.__dict__)
    def save_to_file(self,path):
        temp_article = []
        for art in self.article:
            temp_article.append(art.replace("\"","\\\""))
        self.article = temp_article
        export_text = self.to_json()
        valid_json_formatted_text = format_json(export_text)
        write_text_file(path,valid_json_formatted_text)
        
# Scraping functions
def get_page_content(page_url):
    response = urllib.request.urlopen(page_url)
    page_content = response.read()
    return page_content
    
def get_result_file_path(folder,filename):
    extension = ".json"
    return folder + filename + extension
    
def get_article(url,page_content):
    parser_type = 'html.parser'
    content_soup = BeautifulSoup(page_content, parser_type)
        
    title = content_soup.findAll(article_title_tag_type, article_title_filter)[0].get_text()
    
    content_articles = []
    for content_tag in content_soup.findAll(article_content_tag_type, article_content_filter):
        content_articles.append(content_tag.get_text())

    article = Article(url,title,content_articles)
    return article
    
def get_driver_produced_html(url):
    scroll_script = "window.scrollTo(0, document.body.scrollHeight);"

    driver = webdriver.Chrome(ChromeDriverManager().install())
    driver.get(url)
    driver.execute_script(scroll_script)
    time.sleep(1)

    html = driver.page_source

    driver.close()
    return html
    
def get_article_urls(html):
    article_urls = []

    parser_type = 'html.parser'
    soup = BeautifulSoup(html, parser_type)
    
    for title_tag in soup.find_all(article_header_container_tag_type):
        if article_container_text in title_tag.get_text():
            for article_tag in title_tag.find_all(article_header_tag_type):
                article_urls.append(article_tag.a[article_header_link_attribute])
    return article_urls
    
def scrape_articles(result_folder,article_base_url,list_of_links):
    iteration_number = 0
    for list_of_link in list_of_links:
        page_url = article_base_url + list_of_link
        
        page_content = get_page_content(page_url)
        
        article = get_article(page_url,page_content)
        
        path = get_result_file_path(result_folder,str(iteration_number))
        article.save_to_file(path)
        
        iteration_number = iteration_number + 1
  
# Scraper script
prepare_result_folder(result_folder_path)
html = get_driver_produced_html(main_page_url)
list_of_links = get_article_urls(html)
scrape_articles(result_folder_path,article_base_url,list_of_links)