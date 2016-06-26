<?php
require_once('connection_util.php');

// This request take all the link with our subject
$sparql = "SELECT ?sujet WHERE  {{ ?sujet rdf:type DC:Personnage . } UNION { ?sujet rdf:type DC:Lock . } UNION { ?sujet rdf:type DC:Box . } UNION { ?sujet rdf:type DC:Caillou . }}";
$result = sparql_query( $sparql );
if( !$result ) { print sparql_errno() . ": " . sparql_error(). "\n"; exit; }

$fields = sparql_field_array( $result );

while( $row = sparql_fetch_array( $result ) )
{
    $obj = decode($row[$fields[0]]);
    print('<li><a href="multiplayer.php?object='.$obj.'">'.($subject == $obj ? "_ " : "").$obj.'</a></li>');
}