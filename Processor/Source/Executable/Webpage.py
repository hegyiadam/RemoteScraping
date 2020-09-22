from bs4 import BeautifulSoup
import urllib.request
from selenium import webdriver
from webdriver_manager.chrome import ChromeDriverManager
from selenium.webdriver.chrome.options import Options



class Webpage(object):
    def __init__(self, url):
        self.page_url = url
        chrome_options = Options()
        chrome_options.add_argument("--headless")
        browser = webdriver.Chrome(ChromeDriverManager().install(),options=chrome_options)
        #with urllib.request.urlopen(self.page_url) as f:
        #    self.html = f.read().decode('utf-8')
        #self.soup = BeautifulSoup(self.html, 'html.parser')
        browser.get(url)
        self.soup = BeautifulSoup(browser.page_source,"html.parser")
        browser.close()
        browser.quit()

    def get_content(self):
        return self.html


    def get_element_by_selector(self,selector):
        return self.soup.select_one(selector)
        

