from bs4 import BeautifulSoup
import urllib.request

class Webpage(object):
    def __init__(self, url):
        self.page_url = url
        with urllib.request.urlopen(self.page_url) as f:
            self.html = f.read().decode('utf-8')
        self.soup = BeautifulSoup(self.html, 'html.parser')

    def get_content(self):
        return self.html


    def get_element_by_selector(self,selector):
        return self.soup.select_one(selector)
        

