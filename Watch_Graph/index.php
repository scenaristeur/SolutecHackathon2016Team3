<!DOCTYPE html>
<html>
<head>
    <title>Watch_Graph</title>
    <meta name="description" content="A badass visualisation of the graph data of our badass videogame" />
    <meta charset="UTF-8">
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css" integrity="sha384-fLW2N01lMqjakBkx3l/M9EahuwpSfeNvV63J5ezn3uZzapT0u7EYsXMjQV+0En5r" crossorigin="anonymous">

    <script src="https://code.jquery.com/jquery-2.2.4.min.js"></script>

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" crossorigin="anonymous"></script>
    <script src="lib/go.js"></script>
    <script>

        function post(path, params, method) {
            method = method || "post";
            var form = document.createElement("form");
            form.setAttribute("method", method);
            form.setAttribute("action", path);
            form.setAttribute('target', 'hidden-form');
            console.log(params);

            for(var key in params) {
                if(params.hasOwnProperty(key)) {
                    var hiddenField = document.createElement("input");
                    hiddenField.setAttribute("type", "hidden");
                    hiddenField.setAttribute("name", key);
                    hiddenField.setAttribute("value", params[key]);
                    form.appendChild(hiddenField);
                }
            }
            document.body.appendChild(form);
            form.submit();
        }

        function modifTriplet(_sujetAvant,_propAvant,_objetAvant,_sujetApres,_propApres,_objetApres,_objetType){

            var sujetAvant=_sujetAvant;
            var propAvant=_propAvant;
            var objetAvant=_objetAvant;
            var sujetApres=_sujetApres;
            var propApres=_propApres;
            var objetApres=_objetApres;
            var objetType=_objetType;

            var endpoint="http://192.168.101.39:3030/test/update";
            var updateDeleteComplete="";
            var updateAddComplete="";
            //Initialisation de la variable prefixes avec quelques prefixes
            var prefixes  = "PREFIX rdf:   <http://www.w3.org/1999/02/22-rdf-syntax-ns#> \n";
            prefixes += "PREFIX rdfs:   <http://www.w3.org/2000/01/rdf-schema#> \n";
            prefixes += "PREFIX DC:   <http://www.smag0/NS/hackathonSolutec/DC#> \n";

            var updateDelete=" DELETE DATA { DC:"+sujetAvant+" DC:"+propAvant+" \""+objetAvant+"\" . } \n ";

            //Construction requete insert
            var updateInsert= " INSERT DATA {";
            if (_objetType="literal"){
                console.log("literal");
                updateInsert += "DC:"+sujetApres+"    DC:"+propApres+"         \""+objetApres+"\" .";
            }else{
                updateInsert += "DC:"+sujetApres+"    DC:"+propApres+"         DC:"+objetApres+" .";
            }
            updateInsert += " } ";

            //        update=prefixes+updateDelete+updateInsert;
            updateDeleteComplete=prefixes+updateDelete;
            updateAddComplete=prefixes+updateInsert
            //console.log(updateDeleteComplete);
            //console.log(updateAddComplete);

            post(endpoint, {"update" : updateAddComplete});
            // impossible de concatener les deux requetes DEL et INS ! GRRRR ! -> delai necessaire entre deux requetes post
            setTimeout(function () {
                post(endpoint, {"update" : updateDeleteComplete});
            }, 500);
        }
    </script>
    <script id="code">
        function init() {

            if (window.goSamples) goSamples();  // init for these samples -- you don't need to call this
            var $ = go.GraphObject.make;  // for conciseness in defining templates

            myDiagram =
                $(go.Diagram, "myDiagramDiv",  // must name or refer to the DIV HTML element
                    {
                        // start everything in the middle of the viewport
                        initialContentAlignment: go.Spot.Center,
                        // have mouse wheel events zoom in and out instead of scroll up and down
                        "toolManager.mouseWheelBehavior": go.ToolManager.WheelZoom,
                        // support double-click in background creating a new node
                        "clickCreatingTool.archetypeNodeData": { text: "new node" },
                        // enable undo & redo
                        "undoManager.isEnabled": true
                    });

            // when the document is modified, add a "*" to the title and enable the "Save" button
            myDiagram.addDiagramListener("Modified", function(e) {
                var button = document.getElementById("SaveButton");
                if (button) button.disabled = !myDiagram.isModified;
                var idx = document.title.indexOf("*");
                if (myDiagram.isModified) {
                    if (idx < 0) document.title += "*";
                } else {
                    if (idx >= 0) document.title = document.title.substr(0, idx);
                }
            });

            // define the Node template
            myDiagram.nodeTemplate =
                $(go.Node, "Auto",
                    new go.Binding("location", "loc", go.Point.parse).makeTwoWay(go.Point.stringify),
                    // define the node's outer shape, which will surround the TextBlock
                    $(go.Shape, "RoundedRectangle",
                        {
                            parameter1: 20,  // the corner has a large radius
                            fill: $(go.Brush, "Linear", { 0: "rgb(66,133,244)", 1: "rgb(66,133,244)" }),
                            stroke: null,
                            portId: "",  // this Shape is the Node's port, not the whole Node
                            fromLinkable: true, fromLinkableSelfNode: true, fromLinkableDuplicates: true,
                            toLinkable: true, toLinkableSelfNode: true, toLinkableDuplicates: true,
                            cursor: "pointer"
                        }),
                    $(go.TextBlock,
                        {
                            font: "normal 12pt impact, bold arial, sans-serif",
                            editable: true  // editing the text automatically updates the model data
                        },
                        new go.Binding("text").makeTwoWay())
                );

            // unlike the normal selection Adornment, this one includes a Button
            myDiagram.nodeTemplate.selectionAdornmentTemplate =
                $(go.Adornment, "Spot",
                    $(go.Panel, "Auto",
                        $(go.Shape, { fill: null, stroke: "blue", strokeWidth: 2 }),
                        $(go.Placeholder)  // a Placeholder sizes itself to the selected Node
                    ),
                    // the button to create a "next" node, at the top-right corner
                    $("Button",
                        {
                            alignment: go.Spot.TopRight,
                            click: addNodeAndLink  // this function is defined below
                        },
                        $(go.Shape, "PlusLine", { width: 6, height: 6 })
                    ) // end button
                ); // end Adornment

            // clicking the button inserts a new node to the right of the selected node,
            // and adds a link to that new node
            function addNodeAndLink(e, obj) {
                var adornment = obj.part;
                var diagram = e.diagram;
                diagram.startTransaction("Add State");

                // get the node data for which the user clicked the button
                var fromNode = adornment.adornedPart;
                var fromData = fromNode.data;
                // create a new "State" data object, positioned off to the right of the adorned Node
                var toData = { text: "new" };
                var p = fromNode.location.copy();
                p.x += 200;
                toData.loc = go.Point.stringify(p);  // the "loc" property is a string, not a Point object
                // add the new node data to the model
                var model = diagram.model;
                model.addNodeData(toData);

                // create a link data from the old node data to the new node data
                var linkdata = {
                    from: model.getKeyForNodeData(fromData),  // or just: fromData.id
                    to: model.getKeyForNodeData(toData),
                    text: "transition"
                };
                // and add the link data to the model
                model.addLinkData(linkdata);

                // select the new Node
                var newnode = diagram.findNodeForData(toData);
                diagram.select(newnode);

                diagram.commitTransaction("Add State");

                // if the new node is off-screen, scroll the diagram to show the new node
                diagram.scrollToRect(newnode.actualBounds);
            }

            myDiagram.addDiagramListener("TextEdited", function (e) {
                var oldValue = e.parameter;
                var newValue = e.subject.text;
                var type = e.subject.part.findTreeParentLink().toString().split('(')[1].replace(')', '');
                var object = "<?php print $_GET['object'] ?>";

                modifTriplet(object, type, oldValue, object, type, newValue, "literal");
            });

            // replace the default Link template in the linkTemplateMap
            myDiagram.linkTemplate =
                $(go.Link,  // the whole link panel
                    {
                        curve: go.Link.Bezier, adjusting: go.Link.Stretch,
                        reshapable: true, relinkableFrom: true, relinkableTo: true,
                        toShortLength: 3
                    },
                    new go.Binding("points").makeTwoWay(),
                    new go.Binding("curviness"),
                    $(go.Shape,  // the link shape
                        { strokeWidth: 1.5 }),
                    $(go.Shape,  // the arrowhead
                        { toArrow: "standard", stroke: null }),
                    $(go.Panel, "Auto",
                        $(go.Shape,  // the label background, which becomes transparent around the edges
                            {
                                fill: $(go.Brush, "Radial",
                                    { 0: "rgb(240, 240, 240)", 0.3: "rgb(240, 240, 240)", 1: "rgba(240, 240, 240, 0)" }),
                                stroke: null
                            }),
                        $(go.TextBlock, "transition",  // the label text
                            {
                                textAlign: "center",
                                font: "9pt helvetica, arial, sans-serif",
                                margin: 0,
                                editable: true  // enable in-place editing
                            },
                            // editing the text automatically updates the model data
                            new go.Binding("text").makeTwoWay())
                    )
                );

            // read in the JSON data from the "mySavedModel" element
            load();
        }



        // Show the diagram's model in JSON format
        function save() {
            console.log(document.getElementById("mySavedModel").value);
            document.getElementById("mySavedModel").value = myDiagram.model.toJson();
            console.log(document.getElementById("mySavedModel").value);
        }
        function load() {
            myDiagram.model = go.Model.fromJson(document.getElementById("mySavedModel").value);
        }
    </script>
</head>
<body onload="init()">
<div id="sample">
    <div id="myDiagramDiv" style="border: solid 1px black; width: 100%; height: 400px"></div>
    <div>
    <textarea id="mySavedModel" style="width:100%;height:0" hidden="hidden">
<?php include 'catcher.php'; ?>
    </textarea>
    </div>
    <iframe style="height:0" hidden="hidden" name="hidden-form"></iframe>
</div>
</body>
</html>
