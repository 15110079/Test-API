var app = angular.module("demo2", []); 


app.controller('control', function ($scope, $http) {
    console.log('get api called');
    $http.get("/api/testAPI")
        .then(function (response) {
            $scope.listInfos = response.data;
        });
  
    $scope.hideform = true;
    $scope.openForm = function (id) {
        $scope.hideform = false;
        console.log(id);
        if (id != null) {
            $scope.id = id - 1;
            var object = $scope.listInfos[id - 1];
            $scope.newname = object.name;
            $scope.newage = object.age;
            $scope.newphone = object.phone;
            $scope.newemail = object.email;
        }
        else {
            $scope.id = null;
            $scope.newname = null;
            $scope.newage = null;
            $scope.newphone = null;
            $scope.newemail = null;
        }
    }

    $scope.editMember = function (id) {
        $scope.hideform = false;
        console.log(' here');
        if (id == null) {
            var sendData = {
                name: $scope.newname,
                age: $scope.newage,
                phone: $scope.newphone,
                email: $scope.newemail,
                id: null
            };

            console.log(sendData);
            //$http.post("/api/testAPI", sendData)
            //    .success(function (data, status, headers, config) {
            //        $scope.listInfos = data;

            //    }).error(function (data, status, header, config) {

            //    });

            $http({
                method: "POST",
                url: "/api/test",
                data: sendData
            }).then(function success(response) {
                $scope.listInfos.push(response.data);
            }, function error(response) {

            });
        }
        else {
            $scope.listInfos[id].name = $scope.newname;
            $scope.listInfos[id].age = $scope.newage;
            $scope.listInfos[id].phone = $scope.newphone;
            $scope.listInfos[id].email = $scope.newemail; s
        }
    }
    $scope.deleteMember = function (id) {
        console.log($scope.listInfos);
        $scope.listInfos.splice($scope.listInfos[id - 1], 1);
    }

});
