node {

  stage('Checkout') {
    git url: 'https://github.com/witlac/Ciarp.git',branch: 'master'
  }
  //SignusFinanciero.sln
  stage ('Restore Nuget') {
    bat "dotnet restore Ciarp.sln"
  }
  
  stage('Clean') {
    bat 'dotnet clean Ciarp.sln'
  }
  
  stage('Build') {
    bat 'dotnet build Ciarp.sln --configuration Release'
  }

  stage ('Test') {
    bat "dotnet test Domain.Test/Domain.Test.csproj --logger trx;LogFileName=unit_tests.trx"
    mstest testResultsFile:"**/*.trx", keepLongStdio: true
  }
    

  stage('Publish') {
    bat 'dotnet publish WebApiAngular/WebApiAngular.csproj -c Release -o C:/DeployCiarp'
  } 
  
}