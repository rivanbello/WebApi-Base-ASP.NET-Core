import { Component, OnInit } from "@angular/core";
import { YoutubeModel } from "../service/youtubeModel";
import { YoutubeService } from "../service/youtube.service";

@Component({
  selector: "app-search",
  templateUrl: "./search.component.html"
})
export class SearchComponent {
  constructor(private youtubeService: YoutubeService) {}

  public nextPageToken: string;
  public items: YoutubeModel[];
  public searchText: string;

  searchApi() {
    this.youtubeService.searchItems(this.searchText).subscribe(
      result => {
        this.nextPageToken = result.nextPageToken;
        this.items = result.items;
        console.log(result);
      },
      error => console.log(error)
    );
  }
}
