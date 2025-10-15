import { PostComment } from "../comment/comment.model"
import { PostLike } from "../like/like.model"
import { User } from "../user/user.model"

export class Post {
  id: number = 0
  content: string = ""
  createdAt: Date = new Date()
  user: User = new User()
  likes: PostLike[] = []
  comments: PostComment[] = []
}
