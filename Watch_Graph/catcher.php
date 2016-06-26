<?php
// This library is for interfacing with the RDF server
require_once( "lib/sparqllib.php" );

// This homemade function remove the predicat from the value given by RDF server
function decode($var) {
    return (preg_match(".#.", $var) ? preg_split(".#.", $var)[1] : $var);
}

// This is our subject
$subject = $_GET['object'];

// Connection to the RFD server with database test
$db = sparql_connect( "http://192.168.101.39:3030/test/" );
if( !$db ) { print sparql_errno() . ": " . sparql_error(). "\n"; exit; }
sparql_ns( "DC","http://www.smag0/NS/hackathonSolutec/DC#" );

// This request take all the link with our subject
$sparql = "SELECT * WHERE { DC:".$subject." ?pro ?obj } LIMIT 25";
$result = sparql_query( $sparql );
if( !$result ) { print sparql_errno() . ": " . sparql_error(). "\n"; exit; }

$fields = sparql_field_array( $result );

// We're spliting nodes and edges (arcs because I forgot that edge is called edge...)
$nodes = array();
$arcs = array();

while( $row = sparql_fetch_array( $result ) )
{
    $nodes[] = decode($row[$fields[1]]);
    $arcs[] = decode($row[$fields[0]]);
}

// Building Json for GoJs
$json = "{ \"nodeKeyProperty\": \"id\", \"nodeDataArray\": [{ \"id\": 0, \"text\": \"".$subject."\" }";
$i = 1;
foreach($nodes as $node) {
    $json .= ", { \"id\": ".$i.", \"text\": \"".$node."\" }";
    $i++;
}
$json .= "], \"linkDataArray\": [";
$i = 1;
foreach($arcs as $arc) {
    $json .= "{ \"from\": 0, \"to\": ".$i.", \"text\": \"".$arc."\" },";
    $i++;
}
$json = substr($json, 0, -1) . "]}";

// If you see this, waw it's amazing!
print $json;