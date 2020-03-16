import { Component, OnInit } from "@angular/core";
import { YoutubeService } from "../service/youtube.service";
import { YTResponse } from "../service/YTResponse";
import { YoutubeModel } from "../service/youtubeModel";
import { SearchPipe } from "./pipe";

@Component({
  selector: "app-list",
  templateUrl: "./list.component.html"
})
export class ListComponent implements OnInit {
  constructor(private youtubeService: YoutubeService) {}

  public nextPageToken: string;
  public items: YoutubeModel[];
  public query: string;

  ngOnInit() {
    this.youtubeService.listItems().subscribe(
      result => {
        this.nextPageToken = result.nextPageToken;
        this.items = result.items;
        console.log(result);
      },
      error => console.log(error)
    );
  }
}
