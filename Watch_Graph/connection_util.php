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

// Prefixes definition
sparql_ns( "DC","http://www.smag0/NS/hackathonSolutec/DC#" );
sparql_ns( "rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#" );