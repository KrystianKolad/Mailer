First of all, log in using azure cli:

``` az login```

Then you can initialize your terraform:

``` terraform init ```

And you are ready to go:

``` terraform apply -var 'subscriptionId=YOUR_SUBSCRIPTION_ID'```

Name of storage and app must be unique globally, so you can change it how you like! Example:

``` terrafrom apply -var 'subscriptionId=YOUR_SUBSCRIPTION_ID' -var 'storageName=YOUR_STORAGE_NAME' -var 'appName=YOUR_APP_NAME' ```