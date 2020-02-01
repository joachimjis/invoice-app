export enum RequestState {
    Failed = -1,
    NotAuth = 0,
    Success = 1
}

export interface RequestResult {
    State: RequestState;
    Msg: string;
    Data: AuthenticationData;
}

export interface AuthenticationData {
    accessToken: string;
    userId: number;
}