from flask import Flask
from flaskapp.sql_connection import Connection

app = Flask(__name__)

app.secret_key = '04360346034986dr0'

con = Connection()
con.sqlConnect()

from .routes import main
app.register_blueprint(main)
