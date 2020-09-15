from IExecutable import IExecutable 
from Webpage import Webpage 

class Executable(IExecutable):
    def find_tag_by_css_selector(url, css_selector):
        webpage = Webpage(url)
        print(webpage.get_element_by_selector(css_selector))

##Executable.find_tag_by_css_selector("https://stackoverflow.com/questions/24801548/how-to-use-css-selectors-to-retrieve-specific-links-lying-in-some-class-using-be","#answer-24801950 > div > div.answercell.post-layout--right > div.s-prose.js-post-body")