app.controller("SearchController", function ($scope, $http, SearchService) {
    $scope.divEmpty = false;
    $scope.divpersonnallist = false;
    $scope.InsertForm = false;
    $scope.search = function () {
        $scope.divpersonnallist = true;
        $scope.InsertForm = false;
        $scope.divEmpty = false;
        SearchService.getSearch($scope.searchText).then(function (response) {
            //debugger;
           
            if (response.data.length != 0) {
                $scope.divpersonnallist = true;
                $scope.InsertForm = false;
                $scope.divEmpty = false;
                $scope.personnalList = response.data;
            }
            else {
                $scope.divEmpty = true;
                $scope.divpersonnallist = false;

            }
        }, function () {
            alert("Failed to Retrieve");
        });

    };
    $scope.ShowInsertForms = function () {
        $scope.InsertForm = true;
        $scope.divEmpty = false;
    }
    $scope.InsertData = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            document.getElementById('labelName').innerHTML = "Insert Personnal Information";

            $scope.personnalModel = {};
            $scope.personnalModel.FIRSTNAME = $scope.FIRSTNAME;
            $scope.personnalModel.LASTNAME = $scope.LASTNAME;
            $scope.personnalModel.DODID = $scope.DODID;

            SearchService.Insert($scope.personnalModel).then(function (response) {
                alert(response.data);
                $scope.FIRSTNAME = "";
                $scope.LASTNAME = "";
                $scope.DODID = "";
            })
        }
        else
        {
            $scope.personnalModel = {};
            $scope.personnalModel.FIRSTNAME = $scope.FIRSTNAME;
            $scope.personnalModel.LASTNAME = $scope.LASTNAME;
            $scope.personnalModel.DODID = $scope.DODID;
            $scope.personnalModel.ID = document.getElementById("ID").value;
            SearchService.Update().then(function (response) {
                alert(response.data);
                $scope.FIRSTNAME = "";
                $scope.LASTNAME = "";
                $scope.DODID = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
            })
        }
        }
    $scope.UpdateData = function (personnal)
    {
        // debugger;
        document.getElementById('labelName').innerHTML = "Update Personnal Information";
        $scope.InsertForm = true;
        $scope.divEmpty = false;
        $scope.divpersonnallist = false;
        document.getElementById("ID").value = personnal.ID;
        $scope.FIRSTNAME = personnal.FIRSTNAME;
        $scope.LASTNAME = personnal.LASTNAME;
        $scope.DATEOFBIRTH = personnal.DATEOFBIRTH;
        $scope.DODID = personnal.DODID;
        document.getElementById("btnSave").setAttribute("value", "Update");
    }
})