<?php
require_once( "lib/sparqllib.php" );

function decode($var) {
    return (preg_match(".#.", $var) ? preg_split(".#.", $var)[1] : $var);
}

$subject = $_GET['object'];

$db = sparql_connect( "http://192.168.101.39:3030/test/" );
if( !$db ) { print sparql_errno() . ": " . sparql_error(). "\n"; exit; }
sparql_ns( "DC","http://www.smag0/NS/hackathonSolutec/DC#" );

$sparql = "SELECT * WHERE { DC:".$subject." ?pro ?obj } LIMIT 25";
$result = sparql_query( $sparql );
if( !$result ) { print sparql_errno() . ": " . sparql_error(). "\n"; exit; }

$fields = sparql_field_array( $result );

/*print "<p>Number of rows: ".sparql_num_rows( $result )." results.</p>";
print "<table class='example_table'>";
print "<tr>";
foreach( $fields as $field )
{
    print "<th>$field</th>";
}
print "</tr>";*/

$nodes = array();
$arcs = array();

while( $row = sparql_fetch_array( $result ) )
{
    /*
    print "<tr>";
    foreach( $fields as $field )
    {
        print "<td>". decode($row[$field]) ."</td>";
    }*/
    $nodes[] = decode($row[$fields[1]]);
    $arcs[] = decode($row[$fields[0]]);
    //print "</tr>";
}
//print "</table>";

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

print $json;