import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { APP_BASE_HREF } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { MenuComponent } from "./navigation/menu/menu.component";
import { HomeComponent } from "./navigation/home/home.component";
import { FooterComponent } from "./navigation/footer/footer.component";
import { SearchComponent } from "./youtube/search/search.component";
import { ListComponent } from "./youtube/list/list.component";
import { rootRouterConfig } from "./app.routes";
import { YoutubeService } from "./youtube/service/youtube.service";
import { SearchPipe } from "./youtube/list/pipe";

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HomeComponent,
    FooterComponent,
    SearchComponent,
    ListComponent,
    SearchPipe
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    [RouterModule.forRoot(rootRouterConfig, { useHash: false })]
  ],
  providers: [YoutubeService, { provide: APP_BASE_HREF, useValue: "/" }],
  bootstrap: [AppComponent]
})
export class AppModule {}
