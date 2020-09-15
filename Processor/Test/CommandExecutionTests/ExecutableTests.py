import unittest
from Executable import Executable

class ExecutableTests(unittest.TestCase):
    def test_find_tag_by_css_selector(self):
        result = Executable.find_tag_by_css_selector("https://stackoverflow.com/questions/24801548/how-to-use-css-selectors-to-retrieve-specific-links-lying-in-some-class-using-be","#answer-24801950 > div > div.answercell.post-layout--right > div.s-prose.js-post-body")
        self.assertFalse(result == "")


if __name__ == '__main__':
    unittest.main()