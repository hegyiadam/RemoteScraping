from IResultHandler import IResultHandler 
from MongoHandler import MongoHandler

class ResultWriter(object):
    def __init__(self):
        self.handler = MongoHandler()

    def print_result(self,result):
        self.handler.write_result(result)

