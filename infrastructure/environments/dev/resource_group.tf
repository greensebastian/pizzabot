module "resource_group" {
  source = "../../modules/resource_group"
  env = var.env
  projectname = var.projectname
  region = var.region
}