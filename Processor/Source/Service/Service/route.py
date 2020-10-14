from datetime import datetime
from Service import app
from flask import jsonify,request
import sys
sys.path.append('..\Executable')
from Executable import Executable

@app.route('/run/<command>', methods=['POST'])
def commandExecution(command):
    request_body = request.get_json()
    exec = Executable()
    
    func = getattr(Executable, command)
    print(request_body["params"])
    result = func(*request_body["params"])
    return str(result)
