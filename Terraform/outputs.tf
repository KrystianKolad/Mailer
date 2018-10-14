output "Storage connection string" {
  value = "${azurerm_storage_account.MailerStorage.primary_connection_string}"
}

output "Queue name" {
  value = "${azurerm_storage_queue.MailerQueue.name}"
}
