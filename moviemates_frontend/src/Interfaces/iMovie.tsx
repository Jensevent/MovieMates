import { iGenre } from "./iGenre";

export interface iMovie {
    id: number,
    title: string,
    description: Text,
    imDb: number,
    runTime: string,
    releaseYear: Date,
    platform: number,
    movieGenres: Array<iGenre>,
    amount : number
}

