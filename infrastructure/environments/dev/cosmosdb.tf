module "cosmosdb_account" {
  source = "../../modules/cosmosdb_account"
  env = var.env
  resource_group_name = module.resource_group.resource_group_name
  projectname = var.projectname
}

module "events_table" {
  source = "../../modules/cosmosdb_table"
  env = var.env
  resource_group_name = module.resource_group.resource_group_name
  projectname = "${var.projectname}-events"
  account_name = module.cosmosdb_account.account_name
}