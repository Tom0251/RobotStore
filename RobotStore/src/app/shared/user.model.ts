import { Deserializable } from './deserializable'

export class UserModel implements Deserializable {
    userName: string
    email: string
    fullName: string
    isAdmin: boolean

    deserialize(input: any) {
        Object.assign(this, input);
        return this;
    }
}
