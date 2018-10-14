provider "azurerm" {
    subscription_id = "${var.subscriptionId}"
}

resource "azurerm_resource_group" "MailerGroup" {
    name = "MailerGroup"
    location = "${var.location}"
}

resource "azurerm_storage_account" "MailerStorage" {
    name = "${var.storageName}" //because mailerstorage already taken
    resource_group_name = "${azurerm_resource_group.MailerGroup.name}"
    location = "${var.location}"
    account_tier = "Standard"
    account_replication_type = "LRS"
}

resource "azurerm_storage_queue" "MailerQueue" {
    name = "mailerqueue"
    resource_group_name = "${azurerm_resource_group.MailerGroup.name}"
    storage_account_name = "${azurerm_storage_account.MailerStorage.name}"
}


resource "azurerm_app_service_plan" "MailerServicePlan" {
    name = "MailerServicePlan"
    location = "${var.location}"
    resource_group_name = "${azurerm_resource_group.MailerGroup.name}"

    sku {
        tier = "Standard"
        size = "S1"
    }  
}

resource "azurerm_function_app" "MailerApp" {
    name = "${var.appName}" //because MailerApp already taken
    location = "${var.location}"
    resource_group_name = "${azurerm_resource_group.MailerGroup.name}"
    app_service_plan_id = "${azurerm_app_service_plan.MailerServicePlan.id}"
    storage_connection_string = "${azurerm_storage_account.MailerStorage.primary_connection_string}"
    version = "~2"
    app_settings {
        "SendGridApiKey" = "${var.sendGridApiKey}"
    }
}

