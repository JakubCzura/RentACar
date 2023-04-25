export class RegisterResponse {
    public name: string;
    public surname: string;
    public email: string;

    constructor(name: string, surname: string, email: string) {
        this.name = name;
        this.surname = surname;
        this.email = email;
    }
}