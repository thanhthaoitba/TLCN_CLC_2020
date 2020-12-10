import { Genre } from './genre.models';

export interface Movie {
  id: number;
  key: string;
  name: string;
  over_view: string;
  genres: Array<Genre>;
  rate: string;
  length: string;
  img: string;
  cover: string;
}
