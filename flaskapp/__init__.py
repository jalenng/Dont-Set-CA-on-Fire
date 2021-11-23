from flask import Flask
from flaskapp.sql_connection import Connection

#create flask server
app = Flask(__name__)
app.secret_key = '04360346034986dr0'

#create database connection
con = Connection()
con.sqlConnect()

#setup url routes
from .routes import main
app.register_blueprint(main)
