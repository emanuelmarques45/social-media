import { PostComment } from "./comment.model"
import { PostLike } from "./like.model"
import { RelatedUser } from "./related-user.model"

export class Post {
  id: number = 0
  content: string = ""
  createdAt: Date = new Date()
  userId: string = ""
  user: RelatedUser = new RelatedUser()
  likes: PostLike[] = []
  comments: PostComment[] = []
}
