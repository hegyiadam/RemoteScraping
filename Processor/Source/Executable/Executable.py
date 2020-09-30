from IExecutable import IExecutable 
from ResultWriter import ResultWriter
from Webpage import Webpage 

class Executable(IExecutable):
    def find_tag_by_css_selector(url, css_selector):
        webpage = Webpage(url)
        ResultWriter.print_result(webpage.get_element_by_selector(css_selector))
    def get_page_numbers(url, page_iteration_selector):
        webpage = Webpage(url)
        return webpage.get_page_numbers(page_iteration_selector)
    def do_action_on_iteration(url, page_iteration_selector, iteration_number, action,data):
        webpage = Webpage(url)
        webpage.iterate_through_pages(iteration_number,page_iteration_selector)
        action(webpage,data)
    


webpage = Webpage("http://localhost:5000/")
print( webpage.get_page_numbers('body > div > ul > li'))
#webpage.click_on_element(element)
#print(webpage.get_soup().prettify())

def get_element_by_selector2(webpage,data):
    print(webpage.get_element_by_selector(data['css_selector']))

url = "http://localhost:5000/"
selector = 'body > div > ul > li'
Executable.do_action_on_iteration(url, selector,2,get_element_by_selector2,{'css_selector': "body > div > div > div:nth-child(1) > div.element-text > h3 > a"})

