resource "azurerm_cosmosdb_table" "table" {
  name                = "cdbt-${var.projectname}-${var.env}-${var.region}"
  resource_group_name = var.resource_group_name
  account_name        = var.account_name
}