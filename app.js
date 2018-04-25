var express = require("express");
var http =  require("http");
var app = express();
var moment = require('moment');

function timeConverter(input){
  
  let unixDate = null;
  let naturalDate = null;
    
  const naturalformat = [ "X",
                 "MMMM-D-YYYY", "MM-D-YYYY" , "MM-D-YY",
                 "D-MMMM-YYYY", "D-MM-YYYY", "D-MM-YY",
                 "YYYY-MMMM-D", "YYYY-MM-D", "YY-MM-D"];
  const date = moment(input,naturalformat,false);
  if (date.isValid()){
      unixDate = date.format('X');
      naturalDate = date.format('MMMM D, YYYY');
  }
  let result = `{"unix": ${unixDate}, "natural": "${naturalDate}"}`;
  return result;
}


app.route('/').get(function(req, res, next) {
	res.sendFile(process.cwd() + '/views/index.html');
});

app.get('/:id', function(req, res,id) {
  return res.send(timeConverter(req.params.id));
  res.end();
});

app.listen(3000);
