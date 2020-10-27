from IExecutable import IExecutable 
import sys
sys.path.append('..\Executable\Scrapers')
from CollectorScrapers import CollectorScrapers

class Executable(IExecutable):
    def find_tag_by_css_selector(url, css_selector):
        DataCollectorScrapers.find_tag_by_css_selector(url, css_selector)
    def find_tag_by_css_selector2(url, page_iteration_selector, iteration_number, css_selector):
        DataCollectorScrapers.find_tag_by_css_selector2(url, page_iteration_selector, iteration_number, css_selector)
    def find_tag_by_content(url, text):
        pass
    def find_tag_by_content2(url, page_iteration_selector, iteration_number, text):
        pass
    def count_texts_on_page(url, texts):
        pass
    def count_texts_on_page2(url, page_iteration_selector, iteration_number, texts):
        pass
    def page_contains_text(url, text):
        pass
    def page_contains_text2(url, page_iteration_selector, iteration_number, text):
        pass
    def get_page_numbers_return(url, page_iteration_selector):
        return DataCollectorScrapers.get_page_numbers(url, page_iteration_selector)
    def get_iteration_links_return(url, iteration_selector):
        return DataCollectorScrapers.get_iteration_links(url, iteration_selector)
    def get_iteration_links2_return(url, page_iteration_selector, iteration_number, iteration_selector):
        return DataCollectorScrapers.get_iteration_links2(url, page_iteration_selector, iteration_number, iteration_selector)
    def find_tag_by_css_selector(url, css_selector):
        DataCollectorScrapers.find_tag_by_css_selector(url, css_selector)