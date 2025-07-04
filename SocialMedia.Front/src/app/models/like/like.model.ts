import { Post } from "../post/post.model"

export class PostLike {
  id: number = 0
  postId: number = 0
  userId: string = ""
  createdAt: Date = new Date()
}
