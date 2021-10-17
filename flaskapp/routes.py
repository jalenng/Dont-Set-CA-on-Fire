from flask import Blueprint, jsonify, request
from flaskapp import con

main = Blueprint('main', __name__)

@main.route('/results', methods = ['GET', 'POST'])
def search_item():
    if request.method == 'POST':
        data = request.args
        choice = data['choice']
        id = data['id']
        result = con.updateResults(choice, id)
        return "Done", 200
    else:
        args = request.args
        ids = args['id']
        ids = list(ids.split(","))
        print(ids)
        print(type(ids))
        results = con.getResults(ids)
        print(results)
        return jsonify(results), 200
        