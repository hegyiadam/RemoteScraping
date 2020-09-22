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


class Article:
    def __init__(self,url,title,article):
        self.url = url
        self.title = title
        self.article = article
    def toJson(self):
        return json.dumps(self, default=lambda o: o.__dict__)

folder = "Articles/"
files = glob.glob(folder+'*')
for f in files:
    os.remove(f)


base_page_url = "https://edition.cnn.com/business/investing"
article_base_url = "https://edition.cnn.com"
article_container_text ="More from investing"

driver = webdriver.Chrome(ChromeDriverManager().install())
driver.get(base_page_url)
driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
time.sleep(1)
html = driver.page_source
driver.close()


list_of_links = []
soup = BeautifulSoup(html, 'html.parser')
for title_tag in soup.find_all('section'):
    if article_container_text in title_tag.get_text():
        for article_tag in title_tag.find_all("article"):
            list_of_links.append(article_tag.a['href'])

iteration_number = 0
for list_of_link in list_of_links:
    page_link = article_base_url + list_of_link
    response = urllib.request.urlopen(page_link)
    content_page = response.read()

    content_soup = BeautifulSoup(content_page, 'html.parser')
    title = content_soup.findAll("h1", {"class": "pg-headline"})[0].get_text()
    content_articles = []
    for content_tag in content_soup.findAll("div", {"class": "zn-body__paragraph"}):
        content_articles.append(content_tag.get_text())


    article = Article(page_link,title,content_articles)
    export_text = json.dumps(article.toJson(), indent=4)
    export_text = export_text[1:-1].replace("\\\"","\"").replace("\\\\","\\")


    text_file = open(folder+str(iteration_number)+".json", "w")
    text_file.write(export_text)
    text_file.close()
    iteration_number = iteration_number + 1