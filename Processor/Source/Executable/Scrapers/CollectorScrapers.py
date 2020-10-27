from Webpage import Webpage 

class CollectorScrapers(object):
    def find_tag_by_css_selector(webpage, css_selector):
        result = webpage.get_element_by_selector(css_selector).get_text()
        content = {
            URL: webpage.page_url,
            Content: result
        }
        
        ResultWriter.print_result(content)

    def get_page_numbers(url, page_iteration_selector):
        webpage = Webpage(url)
        return webpage.get_page_numbers(page_iteration_selector)

    def get_iteration_links(webpage, iteration_selector):
        links = webpage.get_iteration_links(iteration_selector)
        return links
    
