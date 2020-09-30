from bs4 import BeautifulSoup
import urllib.request
from selenium import webdriver
from webdriver_manager.chrome import ChromeDriverManager
from selenium.webdriver.chrome.options import Options
from selenium.webdriver import ActionChains
import itertools


class Webpage(object):
    def __init__(self, url):
        self.page_url = url
        chrome_options = Options()
        chrome_options.add_argument("--headless")
        self.browser = webdriver.Chrome(ChromeDriverManager().install(),options=chrome_options)
        #with urllib.request.urlopen(self.page_url) as f:
        #    self.html = f.read().decode('utf-8')
        #self.soup = BeautifulSoup(self.html, 'html.parser')
        self.browser.get(url)
        self.soup = BeautifulSoup(self.browser.page_source,"html.parser")
    def __del__(self):
        self.browser.close()
        self.browser.quit()

    def get_content(self):
        return self.html

    
    def get_element_by_selector(self,selector):
        return self.soup.select_one(selector)
    
    def get_elements_by_selector(self,selector):
        return self.soup.select(selector)

    def get_page_link_by_number(self,iteration_number,page_selector):
        elements = self.get_elements_by_selector(page_selector)
        next_element = [(element) for element in elements if element.get_text() == str(iteration_number)]
        return next_element[0]

    def iterate_through_pages(self,iteration_number,page_selector):
        element = self.get_page_link_by_number(iteration_number,page_selector)
        self.click_on_element(element)

    def click_on_element(self, element):
        driver_element = self.browser.find_element_by_xpath(self.xpath_soup(element))
        ActionChains(self.browser).click(driver_element).perform()
        self.soup = BeautifulSoup(self.browser.page_source,"html.parser")

    def get_soup(self):
        return self.soup
    def xpath_soup(self,element):
        components = []
        child = element if element.name else element.parent
        for parent in child.parents:
            previous = itertools.islice(parent.children, 0, parent.contents.index(child))
            xpath_tag = child.name
            xpath_index = sum(1 for i in previous if i.name == xpath_tag) + 1
            components.append(xpath_tag if xpath_index == 1 else '%s[%d]' % (xpath_tag, xpath_index))
            child = parent
        components.reverse()
        return '/%s' % '/'.join(components)
    
    def get_page_numbers(self,page_selector):
        elements = self.get_elements_by_selector(page_selector)
        numbers = [(int(element.get_text())) for element in elements if element.get_text() != '']
        return numbers
    def get_iteration_links(self,iteration_link_selector):
        elements = self.get_elements_by_selector(iteration_link_selector)
        links = [(element['href']) for element in elements]
        return links