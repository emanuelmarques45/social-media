import { Post } from "../post/post.model"

export class User {
  id: string = ""
  name: string = ""
  userName: string = ""
  email: string = ""
  password: string = ""
  posts: Post[] = []
  profilePicture: string = ""
  profilePictureContentType: string = ""
}
