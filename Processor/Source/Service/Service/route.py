from datetime import datetime
from Service import app
import sys
from flask import jsonify,request
from Executable import Executable

@app.route('/run/<command>', methods=['POST'])
def commandExecution(command):
    request_body = request.get_json()
    exec = Executable()
    
    func = getattr(Executable, command)
    print(request_body["params"])
    func(*request_body["params"])
    return ""
