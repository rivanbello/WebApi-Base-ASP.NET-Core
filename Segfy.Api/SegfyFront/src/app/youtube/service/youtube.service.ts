import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { YTResponse } from "./YTResponse";
import { Observable } from "rxjs";

@Injectable()
export class YoutubeService {
  constructor(private http: HttpClient) {}

  protected UrlService: string =
    "http://segfy-env-1.eba-ny47bphe.us-east-2.elasticbeanstalk.com/";

  listItems(): Observable<YTResponse> {
    return this.http.get<YTResponse>(this.UrlService + "api/youtube/get-items");
  }

  searchItems(query: string): Observable<YTResponse> {
    return this.http.get<YTResponse>(
      this.UrlService + "api/youtube/search/" + query
    );
  }
}
