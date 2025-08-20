/**
 * Give access to the current spreadsheet only
 * @OnlyCurrentDoc
 */

const contentSize = 9;

function doGet(e) {
  Logger.log("I was called")

  var sheet = SpreadsheetApp.getActiveSheet();
  const range = sheet.getRange(1, 1, 1, contentSize);
  const values = range.getValues()[0];
  const json = JSON.stringify(values);
  const output = ContentService.createTextOutput(JSON.stringify(values));
  output.setMimeType(ContentService.MimeType.JSON);
  
  return output;
}

function doPost(e) {
  var results;
  if (results === undefined)
  {
    results = JSON.parse("[{\"category\":\"Bonheur\",\"mood\":\"neutral\",\"reason\":\"test bon\"},{\"category\":\"Anxiete\",\"mood\":\"sad\",\"reason\":\"test an\"},{\"category\":\"Concentration\",\"mood\":\"sad\",\"reason\":\"test c\"},{\"category\":\"Frustration\",\"mood\":\"neutral\",\"reason\":\"test f\"}]");
  }
  else
  {
    results = JSON.parse(results.postData.contents);
  }

  var sheet = SpreadsheetApp.getActiveSheet();
  const headerRange = sheet.getRange(1, 1, 1, contentSize);
  const headers = headerRange.getValues()[0];

  var row = new Array(contentSize);
  row[0] = getDate();

  for(let i = 0; i < results.length; i++) {
    var result = results[i];
    var index = getIndex(result.category, headers);
    if (index === -1)
      continue;
    row[index] = getMood(result.mood);
    row[index+1] = result.reason;
  }

  const nextRow = sheet.getLastRow() + 1;
  sheet.getRange(nextRow, 1, 1, contentSize).setValues([row]);

  const output = ContentService.createTextOutput(JSON.stringify({status: "success"}));
  output.setMimeType(ContentService.MimeType.JSON);
  return output;
}

function getIndex(category, arr){
  const isEqual = (element) => {
    var res = element.localeCompare(category,undefined,{sensitivity: 'base'});
    return res == 0;
  }
  return arr.findIndex(isEqual);
}

function getMood(mood) {
  if (mood == "happy")
      return "h";
  else if (mood == "neutral")
      return "n";
  else 
      return "s";
}

function getDate()
{
  return Utilities.formatDate(new Date(), Session.getScriptTimeZone(), "yyyy-MM-dd");
}