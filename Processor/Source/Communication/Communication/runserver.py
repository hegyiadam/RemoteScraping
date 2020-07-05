"""
This script runs the RestApi application using a development server.
"""

from os import environ
from Communication import app

if __name__ == '__main__':
    HOST = environ.get('SERVER_HOST', 'localhost')
    app.run(HOST, 5555)
