import { User } from "../user/user.model";

export class PostComment {
  id: number = 0
  user?: User = new User()
  content: string = ""
  postId: number = 0
  userId: string = ""
}
