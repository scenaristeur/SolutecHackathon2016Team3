/*
    This function is used to post data
 */
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

/*
    This function is used to update an object
 */
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