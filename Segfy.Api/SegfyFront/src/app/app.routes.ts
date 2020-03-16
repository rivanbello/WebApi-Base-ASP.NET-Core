import { Routes } from "@angular/router";
import { HomeComponent } from "./navigation/home/home.component";
import { SearchComponent } from "./youtube/search/search.component";
import { ListComponent } from "./youtube/list/list.component";

export const rootRouterConfig: Routes = [
  { path: "", redirectTo: "/home", pathMatch: "full" },
  { path: "home", component: HomeComponent },
  { path: "search", component: SearchComponent },
  { path: "list", component: ListComponent }
];
