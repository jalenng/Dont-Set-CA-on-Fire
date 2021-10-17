import pyodbc
import textwrap

class Connection():

    def __init__(self):
        self.cnxn = None
        self.crsr = None

    #sets up the connection to the azure sql database
    def sqlConnect(self):
        driver = '{ODBC Driver 17 for SQL Server}'
        server = 'insert server name here'
        database = 'insert data base'
        username = 'insert username here'
        password = 'insert password here'

        connection_string = textwrap.dedent('''
            Driver={driver};
            Server={server};
            Database={database};
            Uid={username};
            Pwd={password};
            Encrypt=yes;
            TrustServerCertificate=no;
            Connection Timeout=30;
        '''.format(
            driver=driver,
            server=server,
            database=database,
            username=username,
            password=password
        ))

        cnxn: pyodbc.Connection = pyodbc.connect(connection_string)
        self.cnxn = cnxn
        crsr: pyodbc.Cursor = cnxn.cursor()
        self.crsr = crsr

    #updates the database row with the given id and increments the option chosen
    def updateResults(self, choice, id):
        choices = {
            'A': 'ResultsA',
            'B': 'ResultsB',
            'C': 'ResultsC',
            'D': 'ResultsD'
        }
        
        try:
            update_sql = '''
                UPDATE Questions 
                SET {result_column} = {result_column} + 1
                WHERE QuestionID = {question_id};
            '''.format(
                question_id=id,
                result_column = choices[choice]
            )

            self.crsr.execute(update_sql)
            self.crsr.commit()
        except KeyError:
            return "Incorrect Parameter", 400

        return "Done", 201

    #returns how many times the question choices have been selected for a list of ids
    def getResults(self, ids):
        ids = tuple(ids)
        select_sql = '''
            SELECT ResultsA, ResultsB, ResultsC, ResultsD
            FROM Questions
            WHERE QuestionID
        '''
        if len(ids) > 1:
            select_sql += " IN {ids}".format(ids=ids)
        else:
            select_sql += " = {id}".format(id=ids[0])
        self.crsr.execute(select_sql)
        
        i = 0
        results = {}
        for ResultsA, ResultsB, ResultsC, ResultsD in self.crsr:
            results[ids[i]] = [ResultsA, ResultsB, ResultsC, ResultsD]
            i = i + 1

        return results

