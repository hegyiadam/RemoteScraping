from ConfigurationContainer import ConfigurationContainer
from IResultHandler import IResultHandler

class FileHandler(IResultHandler):
    def __init__(self):
        self.config = ConfigurationContainer()

    def write_result(self, content):
        self.config.get_result_location()
        with open(path, "a") as f:
            f.write(content)



