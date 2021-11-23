from flask import Blueprint, jsonify, request
# from flaskapp import con

#blueprint for the url routes for flask server to use
main = Blueprint('main', __name__)

#url route
@main.route('/results', methods = ['GET', 'POST'])
def search_item():
    #post request handling
    if request.method == 'POST':
        data = request.args
        choice = data['choice']
        id = data['id']
        # result = con.updateResults(choice, id)
        return "Done", 200
    #get request handling
    else:
        args = request.args
        ids = args['id']
        ids = list(ids.split(","))
        # results = con.getResults(ids)
        # return jsonify(results), 200
        