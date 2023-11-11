export interface ApiResponse {
    success: boolean;
    message: string;
    responsesingle: Role ;
  }

export interface ApiRolesResponse {
    success: boolean;
    message: string;
    response: Role[];
}
  
 export interface Role {
    id: number | null | undefined;
    name: string | null | undefined;
  }