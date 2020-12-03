from ConfigurationContainer import ConfigurationContainer
from IResultHandler import IResultHandler
import pymongo

class MongoHandler(IResultHandler):
    def __init__(self):
        self.config = ConfigurationContainer()

    def write_result(self, content):
        client = pymongo.MongoClient(self.config.mongo_connection_string())
        db = client[self.config.mongo_database_name()]
        col = db[self.config.mongo_collection_name()]
        col.insert_one(content)

    def clear_results(self):
        client = pymongo.MongoClient(self.config.mongo_connection_string())
        db = client[self.config.mongo_database_name()]
        col = db[self.config.mongo_collection_name()]
        col.remove()
        
    def find_results(self):
        client = pymongo.MongoClient(self.config.mongo_connection_string())
        db = client[self.config.mongo_database_name()]
        col = db[self.config.mongo_collection_name()]
        res = col.find()
        return res

