variable "subscriptionId" {
  type = "string"
}

variable "location" {
    type = "string"
    default = "West Europe"
}

variable "storageName" {
    type = "string"
    default = "mailerstoragetest"
}

variable "appName" {
    type = "string"
    default = "MailerAppTest"
}

variable "sendGridApiKey" {
    type = "string"
}
