<!DOCTYPE html>
<html lang="en" class="no-js">
<head>
    <title>Watch_Graph</title>
    <meta name="description" content="A badass visualisation of the graph data of our badass videogame" />
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="icon" type="image/png" href="favicon.png" />

    <!-- Bootstrap -->
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" integrity="sha384-fLW2N01lMqjakBkx3l/M9EahuwpSfeNvV63J5ezn3uZzapT0u7EYsXMjQV+0En5r" crossorigin="anonymous">

    <link href='http://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'>
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-T8Gy5hrqNKT+hzMclPo118YTQO6cYprQmhrYwIiQ/3axmI1hQomh7Ud2hPOy8SP1" crossorigin="anonymous">

    <!-- Custom CSS -->
    <link href="css/simple-sidebar.css" rel="stylesheet">

    <script src="https://code.jquery.com/jquery-2.2.4.min.js"></script>

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>

    <!-- Library for node graph -->
    <script src="lib/go.js"></script>

    <!-- Our Javascript for the node graph with GoJs -->
    <script id="code" src="js/graph.js"></script>

    <!-- Our Javascript for pushing update to RDF server -->
    <script src="js/RDF.js"></script>

    <!-- A global variable need for knowing the current object used -->
    <script> window.object = "<?php print $_GET['object'] ?>";</script>

    <!-- Menu Toggle Script -->
    <script>
        $("#menu-toggle").click(function(e) {
            e.preventDefault();
            $("#wrapper").toggleClass("toggled");
        });
    </script>
</head>
<body onload="init()">

<!-- The node graph result -->

<div id="wrapper">

    <!-- Sidebar -->
    <div id="sidebar-wrapper">
        <ul class="sidebar-nav">
            <li class="sidebar-brand">
                <a href="multiplayer.php?object=Bob">
                    Watch_Graph
                </a>
            </li>
            <?php include('menu.php'); ?>
        </ul>
    </div>
    <!-- /#sidebar-wrapper -->

    <!-- Page Content -->
    <div id="page-content-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div id="myDiagramDiv"></div>
                    <!-- The badass video in background -->
                    <video class="hide-for-small-only max" poster="http://s3.amazonaws.com/dev.assets.neo4j.com/wp-content/uploads/20160422160353/neo4j-products-hero-video-poster.jpg" loop="" autoplay="">
                        <source type="video/mp4" src="//s3.amazonaws.com/media.neo4j.com/neo4j-products-hero-video-10sec.mp4">Your browser doesn't support HTML5 video tag.</source>
                        Your browser doesn't support HTML5 video tag.
                    </video>
                    <div>
                        <!-- This textarea invisible is needed for containing the Json of our data for the node graph.
                        The Json is generate with our PHP script. -->
                        <textarea id="mySavedModel" style="width:0;height:0" hidden="hidden"><?php include('catcher.php'); ?></textarea>
                    </div>

                    <!-- This iframe is here to avoid popup when we posting data -->
                    <iframe style="height:0" hidden="hidden" name="hidden-form"></iframe>
                </div>
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->

</div>
<!-- /#wrapper -->

</body>
</html>
