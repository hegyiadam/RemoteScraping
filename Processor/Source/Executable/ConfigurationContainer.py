import json 
  
settings_file_location = '..\..\_Globals\settings.json'

class ConfigurationContainer(object):
    def __init__(self):
        self.config = self.read_settings_file()
        
    def get_result_location(self):
        return self.config['file_result_location']

    def mongo_connection_string(self):
        return self.config['mongo_result_location']["connection_string"]

    def mongo_database_name(self):
        return self.config['mongo_result_location']["database_name"]

    def mongo_collection_name(self):
        return self.config['mongo_result_location']["collection_name"]

    def read_settings_file(self):
        file = open(settings_file_location,) 
        data = json.load(file) 
        file.close()
        return data

