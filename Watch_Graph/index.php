<!DOCTYPE html>
<html lang="en" class="no-js">
<head>
    <title>Watch_Graph</title>
    <meta name="description" content="A badass visualisation of the graph data of our badass videogame" />
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" integrity="sha384-fLW2N01lMqjakBkx3l/M9EahuwpSfeNvV63J5ezn3uZzapT0u7EYsXMjQV+0En5r" crossorigin="anonymous">
    <link rel="icon" type="image/png" href="favicon.png" />
    <link href='http://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'>
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-T8Gy5hrqNKT+hzMclPo118YTQO6cYprQmhrYwIiQ/3axmI1hQomh7Ud2hPOy8SP1" crossorigin="anonymous">

    <link rel="stylesheet" href="css/style.css">

    <script src="https://code.jquery.com/jquery-2.2.4.min.js"></script>

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
    <script src="lib/go.js"></script>
    <script id="code" src="js/graph.js"></script>
    <script src="js/RDF.js"></script>
</head>
<body onload="init()">
<video class="hide-for-small-only" poster="http://s3.amazonaws.com/dev.assets.neo4j.com/wp-content/uploads/20160422160353/neo4j-products-hero-video-poster.jpg" loop="" autoplay="">
    <source type="video/mp4" src="//s3.amazonaws.com/media.neo4j.com/neo4j-products-hero-video-10sec.mp4">Your browser doesn't support HTML5 video tag.</source>
    Your browser doesn't support HTML5 video tag.
</video>
<div id="myDiagramDiv"></div>
<div>
    <textarea id="mySavedModel" style="width:0;height:0" hidden="hidden"><?php include 'catcher.php'; ?></textarea>
</div>
<iframe style="height:0" hidden="hidden" name="hidden-form"></iframe>
</body>
</html>
